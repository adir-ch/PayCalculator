### Problem ###

As an employee located in Australia, I would like to see my deductions charged in my wages so that I can correctly calculate my net salary

	Given the employee is located in Australia, a compulsory Superannuation contribution of 8.6758% is applied

	Given the employee is located in Australia, a compulsory Medicare Levy is applied following the conditions bellow:
		Taxable Income <= 21335 = NIL
		Taxable Income > 26668 = 2% is applied
		Taxable Income from $21,336 to $ 26,668, apply 10% over the difference of $21,335. e.g. Taxable Income of $23,000 = (23,000-21,335) x 10% = $166.50

	Given the employee is located in Australia, the income tax is:
		NIL until $18,200 p.a.
		19c for each $1 over 18,200 for taxable income in the range of $18,201 – $37,000 p.a.
		$3,572 plus 32.5c for each $1 over $37,000 for taxable income in the range of $37,001 – $87,000 p.a.
		$19,822 plus 37c for each $1 over $87,000 for taxable income in the range of $87,001 – $180,000 p.a.
		$54,232 plus 45c for each $1 over $180,000 for taxable income of $180,001 and over p.a.

	Given the employee is located in Australia, a compulsory Temporary Budget Repair Levy of 2% on that part of a person's taxable income which exceeds $180,000 is applied.

	Given the employee is located in Australia, he/she is eligible to a low-income tax offset benefit if the taxable income is less than $66,667.
		The maximum tax offset is $445 and is applied to taxable income of $37,000 or less.
		If the taxable income is greater than $37.000 and lower than $66,667, the low-income tax offset benefit is $445 reduced by 1.5 cents for each dollar over $37,000.

	Taxable Income is Annual Salary minus Superannuation.

	In order to calculate the right net annual salary values of Income Tax, Medicare Levy and Temporary Budget Repair Levy needs to be rounded up. E.g. $3,652.97 → $3,653.00


As an employee located in New Zealand, I would like to see my deductions charged in my wages so that I can correctly calculate my net salary

	Given the employee is located in New Zealand, the income tax is:
		10.5% of the taxable income up to $14,000 p.a.
		17.5% of the taxable income over $14,000 and up to $48,000 p.a.
		30% of the taxable income over $48,000 and up to $70,000 p.a.
		33% for the remaining taxable income over $70,000 p.a.

	Given the employee is located in New Zealand, a Social Security and Health contribution of 1.45% up to a maximum of $118,191 is applied.

	Taxable Income is the Annual Salary.

As an employee located in Germany, I would like to see my deductions charged in my wages so that I can correctly calculate my net salary

	Given the employee is located in Germany, the income tax is:
		0% of the taxable income up to €7,664 p.a.
		15% of the taxable income over €7,664 and up to €52,153 p.a.
		42% of the taxable income over €7,664 and up to €250,000 p.a.
		45% of the taxable incomes of €250,001 and over p.a.

	Given the employee is located in Germany, a compulsory solidarity surcharge contribution of 5.5% is applied.

	Taxable Income is the Annual Salary.


The application should prompt the user for the annual salary and the location of the employee.

	Eg:
	Please enter the annual salary: 200,000.00
	Please enter the employee’s location: Australia

The application should output the gross annual salary along with a list of deductions and the net annual salary.

	Eg:
	Employee location: Australia
	Gross Salary: $200,000.00

	Taxable Income: $182,648.40

	Deductions:
	Superannuation: $17,351.60
	Medicare Levy: $3,653.00
	Income Tax: $55,424.00
	Temporary Budget Repair Levy: $53.00

	Net annual salary: $123,518.40
