Release Notes 1.1:

1. How to run instructions:
	
		To Run application: 
	
		A) Make sure PlaySlipDemo is set as startup app. To do so: 
		
		1.1 Right click on PlaySlipDemo Project and Set up as Startup project.
    1.2 Build solution and run.
			
2. Test Inputs and outputs are as is stated in Unit Test Project

3. use route to test api : "http://localhost:56492/api/payslip/GeneratePaySlip"
	Sample input : 
  {	
      "firstName" : "Mandeep",
      "lastName" : "Singh",
      "annualSalary" : 38000,
      "superRate" : 9,
      "startDate" : "01 March – 31 March"
  }
	
	
