<h1><b>his is the Gold Badge Console Applicatin Challenge<b></h1>
<h2>Challenge 1 Komodo Cafe</h2>
<p>Komodo cafe is getting a new menu. The manager wants to be able to create new menu items, delete menu items, and receive a list of all items on the cafe's menu. She needs a console app.</p>
<h2>Challenge 2 Komodo Claims</h2>
<p>Komodo has a bug in its software and needs some new code.</p>
<p>The Claim has the following properties:</p>
<ul>
<li>ClaimID</li>
<li>ClaimType</li>
<li>Description</li>
<li>ClaimAmount</li>
<li>DateOfIncident</li>
<li>DateOfClaim</li>
<li>IsValid</li>
</ul>
<p>The app will need methods to do the following:
Show a claims agent a menu:
Choose a menu item:
1. See all claims
2. Take care of next claim
3. Enter a new claim

For #1, a claims agent could see all items in the queue listed out like this:
ClaimID 	Type 	Description 	Amount 	DateOfAccident 	DateOfClaim 	IsValid
1 	Car 	Car accident on 465. 	$400.00 	4/25/18 	4/27/18 	true
2 	Home 	House fire in kitchen. 	$4000.00 	4/11/18 	4/12/18 	true
3 	Theft 	Stolen pancakes. 	$4.00 	4/27/18 	6/01/18 	false

For #2, when a claims agent needs to deal with an item they see the next item in the queue.
Here are the details for the next claim to be handled:
ClaimID: 1
Type: Car
Description: Car Accident on 464.
Amount: $400.00
DateOfAccident: 4/25/18
DateOfClaim: 4/27/18
IsValid: True
Do you want to deal with this claim now(y/n)? y

When the agent presses 'y', the claim will be pulled off the top of the queue. If the agent presses 'n', it will go back to the main menu.

For #3, when a claims agent enters new data about a claim they will be prompted for questions about it:
Enter the claim id: 4
Enter the claim type: Car
Enter a claim description: Wreck on I-70.
Amount of Damage: $2000.00
Date Of Accident: 4/27/18
Date of Claim: 4/28/18
This claim is valid.</p>

<h2><Challenge 3 Badges</h2>
<p>The Program will allow a security staff member to do the following:
    create a new badge
    update doors on an existing badge.
    delete all doors from an existing badge.
    show a list with all badge numbers and door access
</p>
