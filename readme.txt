
Problem statement is in NETassignment.docx

Before you run make sure that .NET 5 is installed your running machine.

1. Run CostCalculator.Web app. Web application opens Swagger UI.
2. "Try it out" in /calculator/calculate-job. Find the sample request below
{
	"extraMargin": true,
	"Items" : [
		{
			"Name" : "envelopes", 
			"Price" : 520.00
		},
		{
			"Name" : "letterhead", 
			"Price" : 1983.37, 
			"exempt" : true
		}]
}