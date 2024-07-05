CREATE VIEW v_expense AS
SELECT 
    e.idfatura,
    e.idcli,
    e.dataFirstPayment,
    e.type_Of_Expense,
    e.type_Of_Payment,
    d.date_payment,
    d.value_Of_Paymente
FROM 
    expense e
LEFT JOIN 
    details d ON e.idfatura = d.idfatura