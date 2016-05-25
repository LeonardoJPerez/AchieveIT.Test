-- Question #5

SELECT name 
FROM employee 
ORDER BY name;

-- Question #6

SELECT name 
FROM employee 
ORDER BY SUBSTRING(name, CHARINDEX(' ', name) + 1, LEN(name) - CHARINDEX(' ', name) );

-- Question #7

SELECT e.name as "Employee Name", mngr.name as "Manager Name"
FROM employee e
LEFT JOIN employee mngr on e.mgr_id = mngr.id
ORDER BY e.name;

-- Question #8

-- Added UNION to also add Head of Department as part of the result.
SELECT e.name AS "Employee Name" FROM employee e
INNER JOIN department d on e.id = d.head
WHERE d.name = 'Sales'
UNION
SELECT e.name AS "Employee Name" FROM employee e
INNER JOIN department d on e.mgr_id = d.head
WHERE d.name = 'Sales';

-- Question #9

-- Added UNION to also add Head of Department as part of the result.
SELECT e.name as "Employee Name", d.name as 'Department'
FROM employee e
INNER JOIN employee mngr on e.mgr_id = mngr.id
LEFT JOIN department d on d.head = mngr.id
UNION
SELECT e.name as "Employee Name", d.name as 'Department'
FROM employee e
INNER JOIN department d on d.head = e.id
ORDER BY d.name;
 