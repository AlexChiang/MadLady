/* LIMIT & OFFSET */
SELECT(
    SELECT Salary
    FROM Employee
    ORDER BY Salary DESC
    LIMIT 1
    OFFSET 1
) AS SecondHighestSalary

/* SELF JOIN */
SELECT FirstName + ' ' + LastName as FullName
FROM Employee a,
     Employee b
WHERE a.ManagerId = b.ManagerId AND
      a.Salary > b.Salary

/* GRLUP BY | HAVING | COUNT() */
SELECT COUNT(CustomerID), Country
FROM Customers
GROUP BY Country
HAVING COUNT(CustomerID) > 5
ORDER BY COUNT(CustomerID) DESC;

/* DENSE_RANK() */
SELECT Score,
    DENSE_RANK() OVER
        (ORDER BY Score DESC)
    AS Rank
FROM Scores

/* CREATE TABLE */
CREATE Func (N INT) RETURN INT
BEGIN
    SET N = N - 1;
    RETURN
    (
        SELECT Salary As bar
        FROM Employee
        ORDER BY Salary DESC
        LIMIT 1
        OFFSET N
    );
END

/* INSERT */
INSERT INTO Employee (Name ,BDate, Age)
VALUES ('John', '2018-01-05', 25),
        ('Tom', '2020-08-22', 42)

/* DELETE */
DELETE p1
FROM Person p1,
     Person p2
WHERE p1.email = p2.email AND
      p1.Id > p2.Id

/* UPDATE */
UPDATE Salary
SET Sex =
     IF(Sex='f', 'M', 'F')

