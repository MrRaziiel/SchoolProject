CREATE VIEW v_expense AS
SELECT 
    e.idfatura,
    e.idcli,
    e.dataFirstPayment,
    e.type_Of_Expense,
    e.type_Of_Payment,
    d.date_payment,
    d.value_Of_Paymente,
    d.name,
    d.actual_payment,
    d.is_payed
FROM 
    expense e
LEFT JOIN 
    details d ON e.idfatura = d.idfatura

--drop view v_expense