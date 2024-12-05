CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

GO

INSERT INTO Users (Username, Password, Email) VALUES
    ('john_doe', '5f4dcc3b5aa765d61d8327deb882cf99', 'john.doe@example.com');
GO

INSERT INTO Users (Username, Password, Email) VALUES
    ('jane_smith', '7c6a180b36896a0a8c02787eeafb0e4c', 'jane.smith@example.com');
GO

INSERT INTO Users (Username, Password, Email) VALUES
    ('michael_b', '098f6bcd4621d373cade4e832627b4f6', 'michael.b@example.com');
GO

INSERT INTO Users (Username, Password, Email) VALUES
    ('sarah_88', '5ebe2294ecd0e0f08eab7690d2a6ee69', 'sarah88@example.com');
GO

INSERT INTO Users (Username, Password, Email) VALUES
    ('alex_j', 'e99a18c428cb38d5f260853678922e03', 'alex.j@example.com');
GO

INSERT INTO Users (Username, Password, Email) VALUES
    ('emma_w', 'b1946ac92492d2347c6235b4d2611184', 'emma.w@example.com');
GO

INSERT INTO Users (Username, Password, Email) VALUES
    ('charlie_h', '827ccb0eea8a706c4c34a16891f84e7b', 'charlie.h@example.com');
GO

INSERT INTO Users (Username, Password, Email) VALUES
    ('oliver_k', '25d55ad283aa400af464c76d713c07ad', 'oliver.k@example.com');
GO

INSERT INTO Users (Username, Password, Email) VALUES
    ('mia_l', '098f6bcd4621d373cade4e832627b4f6', 'mia.l@example.com');
GO

CREATE TABLE Admin (
    AdminID INT PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

GO

INSERT INTO Admin (AdminID, Username, Password, Email) VALUES
    (192129, 'admin1', 'admin1password', 'admin1@example.com');
GO

INSERT INTO Admin (AdminID, Username, Password, Email) VALUES
    (192130, 'admin2', 'admin2password', 'admin2@example.com');
GO

INSERT INTO Admin (AdminID, Username, Password, Email) VALUES
    (192131, 'superadmin', 'superadminpassword', 'superadmin@example.com');
GO

INSERT INTO Admin (AdminID, Username, Password, Email) VALUES
    (192132, 'main_admin', 'main_adminpassword', 'main.admin@example.com');
GO

INSERT INTO Admin (AdminID, Username, Password, Email) VALUES
    (192133, 'backup_admin', 'backup_adminpassword', 'backup.admin@example.com');
GO

INSERT INTO Admin (AdminID, Username, Password, Email) VALUES
    (192134, 'system_admin', 'system_adminpassword', 'system.admin@example.com');
GO

INSERT INTO Admin (AdminID, Username, Password, Email) VALUES
    (192135, 'network_admin', 'network_adminpassword', 'network.admin@example.com');
GO

INSERT INTO Admin (AdminID, Username, Password, Email) VALUES
    (192136, 'security_admin', 'security_adminpassword', 'security.admin@example.com');
GO

INSERT INTO Admin (AdminID, Username, Password, Email) VALUES
    (192137, 'database_admin', 'database_adminpassword', 'database.admin@example.com');
GO

CREATE TABLE Events (
    EventID INT PRIMARY KEY IDENTITY(1,1),
    EventName NVARCHAR(100) NOT NULL,
    EventDate DATE NOT NULL,
    Location NVARCHAR(100) NOT NULL,
    Attendees INT NOT NULL,
    EventDetails NVARCHAR(255) NOT NULL,
    EventType NVARCHAR(100) NOT NULL
);

GO

INSERT INTO Events (EventName, EventDate, Location, Attendees, EventDetails, EventType) VALUES
    ('Tech Conference 2024', '2024-12-10', 'New York', 500, 'A gathering of technology enthusiasts and industry leaders.', 'Conference'),
    ('Health & Wellness Expo', '2024-12-15', 'Los Angeles', 300, 'An expo focused on health, wellness, and fitness trends.', 'Expo'),
    ('Startup Pitch Night', '2024-12-20', 'San Francisco', 150, 'An event where startups present their ideas to potential investors.', 'Pitch Night'),
    ('AI and Machine Learning Workshop', '2024-12-25', 'Boston', 200, 'A hands-on workshop for learning about AI and machine learning.', 'Workshop'),
    ('Community Meetup', '2024-12-30', 'Chicago', 100, 'A local meetup for community members to network and share ideas.', 'Meetup');
GO

CREATE TABLE VisitorTracking (
    VisitorID INT PRIMARY KEY IDENTITY(1,1),
    VisitDate DATE NOT NULL,
    PageVisited NVARCHAR(100) NOT NULL,
    VisitCount INT NOT NULL
);

GO

INSERT INTO VisitorTracking (VisitDate, PageVisited, VisitCount) VALUES
    ('2024-11-01', 'HomePage', 120),
    ('2024-11-01', 'ContactPage', 45),
    ('2024-11-02', 'HomePage', 150),
    ('2024-11-02', 'ContactPage', 50),
    ('2024-11-03', 'HomePage', 200),
    ('2024-11-03', 'ContactPage', 60),
    ('2024-11-03', 'AboutPage', 30),
    ('2024-11-04', 'HomePage', 170),
    ('2024-11-04', 'ContactPage', 55),
    ('2024-11-04', 'AboutPage', 40),
    ('2024-11-05', 'HomePage', 180),
    ('2024-11-05', 'ContactPage', 65),
    ('2024-11-05', 'AboutPage', 50);
GO