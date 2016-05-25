CREATE TABLE employee
(
	id int Primary key identity(1,1),
	name VARCHAR(255),
	mgr_id int
);

CREATE TABLE department
(
	name VARCHAR(255),
	head int,
	PRIMARY KEY (name, head), 
	FOREIGN KEY (head) REFERENCES employee(id)
);

INSERT INTO employee
VALUES	  ('Jonathan Archer',11),
		  ('Christopher Pike',12),
		  ('James Kirk',13),
		  ('Jean-Luc Picard',14),
		  ('Kathryn Janeway',15),
		  ('Ralph Wiggum',11),
		  ('Troy McClure',12),
		  ('Waylon Smithers',17),
		  ('Edna Krabappel',16),
		  ('Ned Flanders',15),
		  ('Buffy Summers',null),
		  ('Xander Harris',null),
		  ('Willow Rosenberg',null),
		  ('Rupert Giles',null),
		  ('Oz Selbie',null),
		  ('Dade Murphy',11),
		  ('Kate Libby',13),
		  ('Paul Cook',17),
		  ('Emmanuel Goldstein',16),
		  ('Winston Smith',15),
		  ('Thomas Anderson',15),
		  ('Agent Smith',14),
		  ('Malcolm Reynolds',14),
		  ('River Tam',18),
		  ('Jason Nesmith',18);

INSERT INTO department
VALUES	  ('Operations',11),
		  ('Marketing',12),
		  ('IT',13),
		  ('HR',14),
		  ('Sales',15);