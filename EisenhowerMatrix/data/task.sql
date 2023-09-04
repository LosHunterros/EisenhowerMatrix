DROP TABLE IF EXISTS Tasks;


CREATE TABLE tasks (
    [Id]        INT IDENTITY(1,1) PRIMARY KEY,
    [Title]     VARCHAR (250) NOT NULL,
    [Deadline]  DATE        NOT NULL,
    [Important] BIT         NOT NULL,
    [Done]      BIT         NOT NULL,
   
);

INSERT INTO tasks(Title, Deadline, Important, Done) VALUES
('Finish Eisenhower matrix', '10-09-2023',1,0),
('Clean kitchen', '13-09-2023',0,0),
('Go to gym', '20-09-2023',0,0)
;