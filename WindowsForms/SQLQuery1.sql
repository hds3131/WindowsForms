CREATE TABLE BillingDetails (
    ID INT IDENTITY(1,1) PRIMARY KEY,  -- Auto-incrementing ID
    FirstName NVARCHAR(50) NOT NULL,   -- Billing first name
    LastName NVARCHAR(50) NOT NULL,    -- Billing last name
    Address NVARCHAR(255) NOT NULL     -- Billing address
);