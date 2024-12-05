CREATE TABLE PaymentDetails (
    ID INT IDENTITY(1,1) PRIMARY KEY,   -- Auto-incrementing ID
    CardType NVARCHAR(50) NOT NULL,    -- "Debit Card" or "Credit Card"
    CardNumber NVARCHAR(50) NOT NULL,  -- Card number
    ExpiryDate NVARCHAR(10) NOT NULL,  -- Expiry date (e.g., MM/YY)
    CVC NVARCHAR(10) NOT NULL          -- Security code
);