# D Discourse

**CSE 325 - Mastering .NET Group Project**

D Discourse is a social platform built for **focused, topic-based conversations**. Instead of relying on one endless feed where posts can get lost, D Discourse organizes discussions into **boards**, with each board centered on a specific topic.

Users can create boards, publish articles within relevant boards, and join conversations through comments. Visitors can browse and read content without an account, while creating an account is required to participate.

The goal is to provide a simple place for people to explore their interests, share knowledge, ask questions, and build communities around topics they care about; without the noise of a general-purpose social media feed.

## Table of Contents

- [Project Overview](#project-overview)
- [Documentation](#documentation)
- [Core Concepts](#core-concepts)
- [Features and Scope](#features-and-scope)
- [User Access and Permissions](#user-access-and-permissions)
- [Data Model](#data-model)
- [Security](#security)
- [Device Compatibility](#device-compatibility)
- [Development Workflow](#development-workflow)
- [Team Members](#team-members)
- [Project Links](#project-links)

## Project Overview

D Discourse is designed for people who want to explore a specific interest, hobby, field of study, or community in more depth. For example, students can discuss what they are learning, professionals can share knowledge, and hobbyists can exchange ideas and feedback with people who share their interests.

The platform combines the openness of social media with the organized, topic-focused structure of a forum. Boards help keep content grouped by subject, while articles and comments provide a place for discussion.

## Documentation

- **[User Guide](docs/USER-GUIDE.md):** how to browse boards, create an account, publish articles, and join discussions.

## Core Concepts

- **Boards:** Topic-focused spaces where related articles and discussions are organized.
- **Articles:** Posts published within a board to share ideas, updates, questions, or information.
- **Comments:** Responses attached to articles that allow users to discuss the content.
- **User accounts:** Accounts that identify users and allow them to participate in the platform.
- **Permissions:** User permission levels, such as administrator, moderator, and contributor, help manage boards and community content.

## Features and Scope

The following features are defined based on team collective ideas and agreement. Their availability in the deployed application depends on the current implementation.

### Accounts and permissions

- Create and manage user accounts.
- Delete a user's own account.
- Support permission levels such as administrator, moderator, and contributor.
- Allow visitors to browse and read content without signing in.
- Require users to sign in before interacting with the platform.

### Boards

- Create boards for specific discussion topics.
- Manage boards according to the user's permissions.
- Delete boards created by the user, subject to applicable permissions.
- Browse, search, sort, and filter boards.

### Articles

- Create articles within relevant boards.
- Update and delete articles created by the user.
- Browse, search, sort, and filter articles.
- Like or rate articles published by other users.

### Comments and discussions

- Create comments on articles.
- Update and delete comments created by the user.
- Read comments and follow discussions associated with an article.

### Out of scope

To keep the project manageable, the following functionality is outside the planned scope:

- Advanced interaction with comments.
- Searching, sorting, or filtering comments.
- Liking or rating other users' comments.

These limitations apply to comments; they do not exclude the planned search, sort, and filter features for boards and articles.

## User Access and Permissions

D Discourse supports browsing without requiring an account, but users must create an account and sign in before interacting with content.

The planned access rules are:

- **Visitors:** Can browse boards and read articles without an account.
- **Signed-in users:** Can create articles and comments and manage the articles and comments they created.
- **Users with appropriate permissions:** Can create and manage boards according to their assigned permissions.
- **Administrators and moderators:** Have permission levels intended to support management of content and discussions as the community grows.

The exact actions available to each permission level are determined by the application's implementation.

External authentication through OAuth is identified as an optional feature.

## Data Model

The meeting summary identifies the following core entities and fields.

| Entity        | Fields                                                                                                                                                                           |
| ------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| User Accounts | User ID (primary key), username (unique), email (unique), hashed password (nullable when external authentication is used), profile photo (optional), permissions (required enum) |
| Boards        | Board ID (primary key), user ID (foreign key), name                                                                                                                              |
| Articles      | Article ID (primary key), board ID (foreign key), user ID (foreign key), title, text, timestamp, rating                                                                          |
| Comments      | Comment ID (primary key), article ID (foreign key), user ID (foreign key), text, timestamp                                                                                       |

This model associates each board with a user, each article with both a board and its author, and each comment with an article and its author.

## Security

The project plan identifies the following basic security practices:

- Hash passwords for accounts that use on-platform authentication.
- Rely on the security mechanisms of an external provider when OAuth authentication is used.
- Use the deployment platform's database security capabilities.
- Store secrets in environment variables and keep them out of version control using `.gitignore`.
- Do not commit passwords, API keys, connection strings, or other sensitive configuration to GitHub.

## Device Compatibility

D Discourse is a web application intended to work across platforms through modern web browsers.

The interface should use responsive design to provide a usable experience on both desktop and mobile browsers.

## Development Workflow

All team members should follow the workflow below to keep development organized and the main branch stable.

### Update Workspace

- Before begin working, always remember to update your workspace by making a pull request
- Always Check to make sure the pull request is done on the main branch, not on your created branch

### Branching

1. Do not work directly on the main branch.
2. Create a separate branch for each feature, fix, or improvement.
3. Keep branch names descriptive and related to the task.

### Pull requests and reviews

1. Commit and push your changes to your working branch.
2. Open a pull request (PR) against the appropriate target branch.
3. Notify the team when the PR is ready for review.
4. Wait for at least one other team member to review the PR before merging.
5. Address review feedback and make any necessary changes before merging.

**Do not merge a pull request before at least one team member has reviewed it.**

### Communication and task tracking

- Use the Trello board to review tasks, assignments, and project progress.
- Keep task status current.
- Inform the team about progress, blockers, and changes that may affect other members.
- Test your changes before opening a pull request.

### Code quality

- Follow the existing project structure and coding conventions.
- Write readable, maintainable code.
- Avoid unnecessary complexity and duplication.
- Add comments or documentation where they help explain non-obvious code.

## Team Members

The project team consists of:

- **Daniel Chukwunalu Opute**
- **Jacob Nielsen**
- **Adeoye Johnson Ogunleye**

## Project Links

- **GitHub Repository:** [danisms/cse325-group-project](https://github.com/danisms/ddiscourse)
- **Trello Board:** [CSE 325 Group Project](https://trello.com/b/POyUX8NE/cse325-group-project)
- **Deployed Application:** [ddiscourse.runasp.net](https://ddiscourse.runasp.net)
- **User Guide:** [USER-GUIDE](docs/USER-GUIDE.md)

## Project Information

**Course:** CSE 325 - Mastering .NET  
**Project:** D Discourse  
**Tagline:** Read · Write · Discuss

---

_This README describes the project's agreed scope and intended functionality. Some features may still be under development and may not yet be available in the deployed application._
