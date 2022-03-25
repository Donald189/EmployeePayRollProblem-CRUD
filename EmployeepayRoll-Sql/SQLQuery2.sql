alter procedure SpAddEmployeeDetails
(
@EmployeeName varchar(255),
@PhoneNumber varchar(10),
@Address varchar(255),
@Department varchar(255),
@Gender char(1),
@BasicPay float,
@Deductions float,
@TaxablePay float,
@Tax float,
@NetPay float,
@StartDate Date,
@City varchar(255),
@Country varchar(255)
)
as begin
Insert into employee values(@EmployeeName,@PhoneNumber,@Address,
@Department,@Gender,@BasicPay,@Deductions,@TaxablePay,@Tax,@NetPay,
@StartDate,@City,@Country)
end