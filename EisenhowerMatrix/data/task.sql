DROP TABLE IF EXISTS Tasks;


CREATE TABLE tasks (
    [Id]        INT IDENTITY(1,1) PRIMARY KEY,
    [Title]     VARCHAR (250) NOT NULL,
    [Deadline]  DATE        NOT NULL,
    [Important] BIT         NOT NULL,
    [Done]      BIT         NOT NULL,
   
);

INSERT INTO tasks(Title, Deadline, Important, Done) VALUES
('Finish Eisenhower matrix', '2023-09-10',1,0),
('Clean kitchen', '2023-09-13',0,0),
('Go to gym', '2023-09-15',0,0)
;