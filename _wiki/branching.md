# Branching and Pull Requests

## Create branches for work items

Select New Branch:

![](pasted-image-170421115452.png)

Name branch to reflect task or general area you're working on, and, if possible, specify the work item it applies to:

![](pasted-image-170421115615.png)

New branch should appear in Visual Studio. You can then make it your working branch by double clicking, fetch (also can use git command line):

![](pasted-image-170421115759.png)

If the new branch does not show up in remotes/origin, use git command line as follows:

![](pasted-image-170421115912.png)

## Pull Requests (Coming Soon)

After committing changes to your local branch and pushing to server, create a pull request:

Select New Pull Request:

![](pasted-image-170421120445.png)

Make sure you're committing the correct branch, and that it is linked to a work item:

![](pasted-image-170421120555.png)

After clicking New Pull Request from the above screen, the team will be notified.  Before completing the request, which will merge the branch to master (and trigger build and release to dev), team can comment and approve the pull request.