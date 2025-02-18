CREATE TABLE RequestTemplates (
    TemplateID INT IDENTITY(1,1) PRIMARY KEY,
    RequestType NVARCHAR(50) CHECK (RequestType IN ('Payment', 'Expense', 'Purchase')),
    CreatorID INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    ApprovalStatus NVARCHAR(20) CHECK (ApprovalStatus IN ('Pending', 'Approved', 'Rejected')),
    ApproverID INT NULL,
    ApprovedAt DATETIME NULL,
    ModificationHistory NVARCHAR(MAX),
    PrintStatus BIT DEFAULT 0
);

CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(256) NOT NULL,
    Role NVARCHAR(50) CHECK (Role IN ('Employee', 'Manager', 'Admin')),
    BranchID INT NOT NULL
);

CREATE TABLE UserRoles (
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE UserPermissions (
    PermissionID INT IDENTITY(1,1) PRIMARY KEY,
    RoleID INT FOREIGN KEY REFERENCES UserRoles(RoleID) ON DELETE CASCADE,
    Permission NVARCHAR(100) NOT NULL
);

CREATE TABLE UserRoleAssignments (
    AssignmentID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT FOREIGN KEY REFERENCES Users(UserID) ON DELETE CASCADE,
    RoleID INT FOREIGN KEY REFERENCES UserRoles(RoleID) ON DELETE CASCADE
);

CREATE TABLE Branches (
    BranchID INT IDENTITY(1,1) PRIMARY KEY,
    BranchName NVARCHAR(100) NOT NULL,
    Location NVARCHAR(255) NOT NULL
);

CREATE TABLE RequestItems (
    ItemID INT IDENTITY(1,1) PRIMARY KEY,
    TemplateID INT FOREIGN KEY REFERENCES RequestTemplates(TemplateID) ON DELETE CASCADE,
    PartNumber NVARCHAR(50) NULL, -- Only for purchase requests
    Description NVARCHAR(255) NOT NULL,
    Quantity INT CHECK (Quantity > 0),
    UnitPrice DECIMAL(18,2) NULL
);

CREATE TABLE AuditLogs (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    TemplateID INT FOREIGN KEY REFERENCES RequestTemplates(TemplateID) ON DELETE CASCADE,
    Action NVARCHAR(50),
    PerformedBy INT FOREIGN KEY REFERENCES Users(UserID),
    Timestamp DATETIME DEFAULT GETDATE()
);

CREATE TABLE ERPIntegration (
    IntegrationID INT IDENTITY(1,1) PRIMARY KEY,
    TemplateID INT FOREIGN KEY REFERENCES RequestTemplates(TemplateID) ON DELETE CASCADE,
    ERPResponse NVARCHAR(MAX), -- Stores queried part/item lists from ERP system
    QueriedAt DATETIME DEFAULT GETDATE()
);

-- Indexing for performance
CREATE INDEX IX_RequestTemplates_CreatorID ON RequestTemplates(CreatorID);
CREATE INDEX IX_RequestTemplates_ApprovalStatus ON RequestTemplates(ApprovalStatus);
CREATE INDEX IX_RequestItems_TemplateID ON RequestItems(TemplateID);
CREATE INDEX IX_AuditLogs_TemplateID ON AuditLogs(TemplateID);

-- Default constraints for logical workflow
ALTER TABLE RequestTemplates ADD CONSTRAINT DF_ApprovalStatus DEFAULT 'Pending' FOR ApprovalStatus;
ALTER TABLE RequestTemplates ADD CONSTRAINT DF_PrintStatus DEFAULT 0 FOR PrintStatus;
