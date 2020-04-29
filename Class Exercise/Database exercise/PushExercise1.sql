CREATE Table Country(
CountryId INT NOT NULL IDENTITY(1,1),
CountryName NVARCHAR(50) NOT NULL,
PRIMARY KEY(CountryId)
);

CREATE Table State(
StateId INT NOT NULL IDENTITY(1,1),
CountryId INT,
StateName NVARCHAR(50) NOT NULL,
PRIMARY KEY(StateId),
FOREIGN KEY(CountryId) REFERENCES Country(CountryId)
);

INSERT INTO Country
Values('US');

INSERT INTO Country
Values('Japan');

INSERT INTO Country
Values('France');

INSERT INTO Country
Values('Mexico');

INSERT INTO State
Values(1,'Texas');

INSERT INTO State
Values(2,'Tokyo');

INSERT INTO State
Values(3,'Paris');

INSERT INTO State
Values(4,'Yucatan');

INSERT INTO State
Values(null,'Shanghai');

--Join Methods
Select * from Country as c
join State as s
on c.CountryId = s.CountryId
order by s.StateName;

Select * from Country as c
left join State as s
on c.CountryId = s.CountryId;

Select c.CountryName,s.StateName from Country as c
right join State as s
on c.CountryId = s.CountryId;

Select * from Country
full join State
on Country.CountryId = State.CountryId
order by Country.CountryName;

