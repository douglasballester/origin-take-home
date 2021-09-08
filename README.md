# Origin Backend Take-Home
- This Application was develop using .Net 5
- Information about what this application does are available at:
  > https://github.com/OriginFinancial/origin-backend-take-home-assignment

# 1. Instructions to run the project using Docker
- Open your terminal at the root folder (where Origin.sln is located and also the Dockerfile)
- Run the following command `docker build -t origin-take-home` .
- Then to run the project just run `docker run -d -p 5000:80/tcp --name origin origin-take-home`
- Finally, try to access http://localhost:5000/swagger/index.html to reach the swagger page for this application
- If the page has loaded successfully, you are now running the API

# 2. Technical decisions
## 2.1 Score Calculation Engine
 - The score calculation engine was developed to add or remove rules for each type of insurance in the calculation risk in an easy way. Each rule does n validations and can add or deduct the main score of the insurance that is calling this rule. Moreover, you can implement the rule to set the insurance status to ineligible. 
 - Add or remove any rule for specific insurance without changing other insurance

## 2.2 Rules
 - The rules engine was developed to be used for other entities in the future, which is why it was implemented using generic types.
 - At insurance scope, all the rules have a method called Validate and receive the insurance that is being validated and the user parameters. Within the rule you can implement any business logic that you want.
 - The static class RunRule has the static method `For`, which receives two params (in this case Insurance and User), this method returns another class called ValidationRules. This class has two important methods, the first is the `Add` that add a new rule to the list, and the second is the method named `Run` to run synchronously all the rules added for specific insurance.

## 2.3 Insurances
 - Like the score calculation, add new insurances to the calculation risk is quite simple, just extend the base class `Insurance` and add the rules for this insurance for the score calculation.
 - All insurances have a base method to calculate the risk based on the final score, but each insurance can override it and make a new calculation risk for this specific insurance.


# 3 Relevant comments about the project
 - I configured a simple notification to give feedback for the user, for example: If age is below zero, returns a custom message with BadRequest status.
 - Some unit tests are executed more than one time with different input data
 - All unit tests related to rules are strictly tested 
