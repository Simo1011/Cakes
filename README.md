# Cakes
Crud Operation Demo using Razor Pages
Simple Table Cake 
![image](https://user-images.githubusercontent.com/26320160/185773918-2ac2ace1-008e-44fd-bbc0-41c9da58883f.png)
//===Update==
![image](https://user-images.githubusercontent.com/26320160/185773934-3bf3e14d-a4f8-4998-895c-bbb6187ad0ed.png)
//===SQL Create the table ==
CREATE TABLE [dbo].[Cake] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (MAX)   NULL,
    [Price]       DECIMAL (18, 2) NULL,
    [Description] VARCHAR (MAX)   NULL
);

