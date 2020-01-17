# Welcome to the 25th Annual World Famous Silver Pirate Band Pie Auction

## Setup

This repo has the Frontend and Backend bundled together, so you only have to clone and push one repo!

To work on this repo, you will need to fork it to your own GitHub (Click Fork in the right hand side of this repo page).

Once you have this repo in your GitHub, clone it to your desktop using GitHub Desktop.

## Instructions

### Step One

The first step is to take a look around this application! Make sure you have it cloned from your GitHub to your desktop. 

- Open PieAuction.BackEnd in Visual Studio
    - Go ahead and run it (F5)
- Open the PieAuction.FrontEnd folder in Visual Studio Code
    - Remember to use the terminal (open with Ctrl-~) and type `live-server` to launch it and have it reload on save

Take a quick tour of all the code. Don't feel like you have to fully understand every single line of code, but see if you understand the general feel and could navigate in the code.

Once you have both applications running, play around in the application. Can you see data? Can you click on rows and see detail pages? Does the search functionality work like you expect?

- [ ] Does the application run?
- [ ] Does the Frontend act like you expect?
- [ ] Does the Backend respond to the Frontend like you expect?
- [ ] Does the application use a PieAuction.db file? Where is it? How did it get there?

### Step Two

It has been a while since we touched the Frontend, and you may be feeling a little rusty. Lucky for us, [@alyraptor](https://github.com/alyraptor) has put together an awesome Frontend refresher document! Please read through the refresher, and see if it still makes sense to you!

- [ ] Read https://github.com/PercyODI/Stage2.PieAuction/blob/master/FrontEndNotes.md

### Step Three

Now that you have taken a quick look around and actually used the application, let's find out what does and doesn't make sense.

We will use GitHub issues to share and communicate. First, let's make some issues on my repo (not yours!) [PieAuction (Instructor's)](https://github.com/PercyODI/Stage2.PieAuction)

Then, click on the issues tab
![Issues Tab Location](/Instruction.Images/ClickIssues.JPG?raw=true)

To make a new issue, click the "New Issue" button
![New Issue Location](/Instruction.Images/ClickNewIssue.JPG?raw=true)

Once there, give your question a good title, and put some meaningful information in the comments.

The comments is a good place for an in-depth message. It is super helpful to include files and filelines, exception messages, debug messages, and your installation setup (if applicable).

You need to leave at least three (3) issues about the code, front or back end. These questions can be anything you don't understand, or would like an explanation on. Be sure to give them the `question` label!

See this issue for an example: https://github.com/PercyODI/Stage2.PieAuction/issues/2 

- [ ] Leave at least three (3) issues
- [ ] Look at issues from others. Can you answer their question? if so, leave a comment!
- [ ] When a question you have is answered, look at the answer and see if it makes sense. 
    - If it doesn't, add another comment asking for more information.
    - If it does, close the issue.

### Step Four

Time for some features! As you can probably already tell, there are some parts of the application that aren't fully fleshed out. The product owner for this application has asked for bidding to be implemented and displayed on the pie pages. 

Our architects have tentatively decided on the following ERD for the Pie, AuctionUser, and Bid models. Try to stick to it as closely as possible, but feel free to make any changes you deem necessary!

![Backend ERD](/Instruction.Images/ERD.jpg?raw=true)

You will start to see mentors adding issues to **your** repo. These issues are feature requests and bugs that need to be implemented in your code. If something is unclear in the issue, please comment in it so that the poster can clarify.

When you decide on an issue to work on, follow these steps:

1. Comment in the issue that you are taking a look at it
2. Make comments if anything needs clarified or explained
3. Implement the issue 
    - If it is a bug, fix the bug
    - If it is a feature, add the feature
4. Once you have it working, commit your code using GitHub Desktop
    - In your commit summary, use the words "resolves #123", but replace "123" with the issue number
        - The issue number can be found at the end of the URL 
        - It can also be found at the end of the issue title
        - ![Issue Number Location](/Instruction.Images/IssueNumberLocation.JPG?raw=true)
        - Be sure to keep the pound sign (hashtag) in front of the number
5. Push the changes up to GitHub
6. Confirm in GitHub that the issue was closed 
    - By using the phrase "resolves #123", GitHub will automatically close issue 123.
    - If it is not automatically closed, close the issue manually, with a comment explanation. 
7. Move on to a new issue

Mentors will be monitoring issues. If you mark an issue closed, a mentor may pick up your repo, try it, and confirm it is working as expected. If there is an issue, they will reopen the issue. When looking for an issue to work on, prioritize reopened issues over new issues!

If you happen to find a bug that is out of scope of your current work, feel free to add your own issues to your repo! That way, you won't lose them!

If you have any questions or need any help, please reach out on Slack! We will be monitoring GitHub, but since we don't see you in person, we can't tell if you are struggling or not!
