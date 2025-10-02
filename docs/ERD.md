# Database Entity Relationship Diagram

```
+-------------+      +-------------+      +------------+
|  Projects   |1----*|   Boards    |1----*|   Tasks    |
+-------------+      +-------------+      +------------+
| Id          |      | Id          |      | Id         |
| Name        |      | Name        |      | Title      |
| Description |      | ProjectId FK|      | BoardId FK |
| OrgId       |      | IsArchived  |      | Priority   |
+-------------+      +-------------+      | Status     |
                                           | DueDate    |
                                           +------------+
                                                |
                                                |1
                                                *
                                          +-------------+
                                          |  Comments   |
                                          +-------------+
                                          | Id          |
                                          | TaskId FK   |
                                          | AuthorId    |
                                          | Message     |
                                          +-------------+
```

Additional associative tables such as `UserProjects`, `UserTasks`, and `Teams` manage memberships, while audit columns track lifecycle events for every aggregate.
