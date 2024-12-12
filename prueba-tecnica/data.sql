-- Crear la tabla de Roles
CREATE TABLE Roles (
    RoleID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(255) NOT NULL,
    Description NVARCHAR(1000)
);

-- Crear la tabla de Users
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(255) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL
);

-- Crear la tabla intermedia UserRoles para la relación muchos a muchos entre Users y Roles
CREATE TABLE UserRoles (
    ID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    RoleID INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);

-- Crear la tabla de Procedures (Procedimientos)
CREATE TABLE Procedures (
    ProcedureID INT PRIMARY KEY IDENTITY(1,1),
    ProcedureName NVARCHAR(255) NOT NULL,
    Description NVARCHAR(1000),
    CreatedByUserID INT,
    CreatedDate DATETIME DEFAULT GETDATE(),
    LastModifiedUserID INT,
    LastModifiedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CreatedByUserID) REFERENCES Users(UserID),
    FOREIGN KEY (LastModifiedUserID) REFERENCES Users(UserID)
);

-- Crear la tabla de Fields
CREATE TABLE Fields (
    FieldID INT PRIMARY KEY IDENTITY(1,1),
    FieldName NVARCHAR(255) NOT NULL,
    DataType NVARCHAR(50) NOT NULL
);

-- Crear la tabla de DataSets
CREATE TABLE DataSets (
    DataSetID INT PRIMARY KEY IDENTITY(1,1),
    DataSetName NVARCHAR(255) NOT NULL,
    Description NVARCHAR(1000),
    ProcedureID INT NOT NULL,
    FieldID INT NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    LastModifiedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ProcedureID) REFERENCES Procedures(ProcedureID),
    FOREIGN KEY (FieldID) REFERENCES Fields(FieldID)
);

-- Insertar Roles (sin especificar el RoleID, lo genera SQL Server automáticamente)
INSERT INTO Roles (RoleName, Description)
VALUES
    ('Admin', 'Administrator role'),
    ('User', 'Regular user role');
    
-- Insertar Users (sin especificar el UserID, lo genera SQL Server automáticamente)
INSERT INTO Users (Username, Password, Email)
VALUES
    ('admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 'admin@example.com'),
    ('user1', 'e606e38b0d8c19b24cf0ee3808183162ea7cd63ff7912dbb22b5e803286b4446', 'user1@example.com');

-- Insertar UserRoles (sin especificar el ID, lo genera SQL Server automáticamente)
-- Notar que estamos usando el UserID y RoleID que serán generados automáticamente
-- al insertar los datos en las tablas correspondientes
INSERT INTO UserRoles (UserID, RoleID)
VALUES
    (1, 1),
    (2, 2);
    
-- Insertar Procedures (sin especificar el ProcedureID, lo genera SQL Server automáticamente)
-- Usamos UserID de los usuarios previamente insertados
INSERT INTO Procedures (ProcedureName, Description, CreatedByUserID, LastModifiedUserID)
VALUES
    ('Data Cleaning', 'Removes duplicates and standardizes formats', 1, 1),
    ('Statistical Analysis', 'Performs basic statistical calculations', 1, 1),
    ('Data Visualization', 'Creates charts and graphs from data', 2, 2),
    ('Machine Learning Model', 'Trains and applies ML models to data', 1, 2),
    ('Data Integration', 'Merges data from multiple sources', 2, 1);
    
-- Insertar Fields (sin especificar el FieldID, lo genera SQL Server automáticamente)
INSERT INTO Fields (FieldName, DataType)
VALUES
    ('SampleField1', 'varchar'),
    ('SampleField2', 'int');
    
-- Insertar DataSets (sin especificar el DataSetID, lo genera SQL Server automáticamente)
-- Usamos ProcedureID y FieldID que serán generados automáticamente
INSERT INTO DataSets (DataSetName, Description, ProcedureID, FieldID)
VALUES
    ('Sales Data 2023', 'Annual sales figures', 1, 1),
    ('Customer Feedback', 'Survey responses from Q2', 2, 2),
    ('Website Traffic', 'Daily visitor counts', 3, 2),
    ('Product Inventory', 'Current stock levels', 1, 2),
    ('Employee Performance', 'Quarterly KPI data', 2, 1),
    ('Marketing Campaign Results', 'ROI for recent campaigns', 3, 1),
    ('Supply Chain Data', 'Supplier delivery times', 4, 2),
    ('Customer Segmentation', 'Demographic clusters', 4, 2),
    ('Social Media Metrics', 'Engagement rates across platforms', 3, 1),
    ('Financial Forecasts', 'Projected revenue for next FY', 2, 1),
    ('Product Returns', 'Reasons for customer returns', 1, 1),
    ('Website Heatmaps', 'User interaction patterns', 3, 2),
    ('Customer Churn Prediction', 'ML model input data', 4, 2),
    ('Competitor Price Analysis', 'Market rate comparisons', 2, 2),
    ('IoT Sensor Data', 'Raw data from factory sensors', 5, 2);
