# Exercise 1: Clean Up and Push Back to Remote Git

**Hands-on ID:** Git-T03-HOL_002
**Estimated time:** 10 minutes

## Objective
Execute the steps involved in cleaning up a local Git workspace and pushing pending
changes back to the remote repository.

## Steps & Commands

### 1. Verify the local branch is in a clean state
```bash
git status
```
```
On branch main
Your branch is up to date with 'origin/main'.

nothing to commit, working tree clean
```

### 2. List all available branches (local + remote)
```bash
git branch -a
```
```
* main
  remotes/origin/main
```

### 3. Create the hands-on branch and make changes
```bash
git checkout -b Git-T03-HOL_002
# ... work done, e.g. adding InventoryService.cs ...
git add .
git commit -m "Git-T03-HOL_002: Add InventoryService skeleton"
```

### 4. Switch back to main and pull the latest from remote
```bash
git checkout main
git pull origin main
```
```
On branch main
Your branch is up to date with 'origin/main'.
nothing to commit, working tree clean
```

### 5. Merge the hands-on branch into main
```bash
git merge Git-T03-HOL_002 -m "Merge Git-T03-HOL_002 into main"
git log --oneline
```
```
18760c4 Git-T03-HOL_002: Add InventoryService skeleton
0c3d001 Initial commit
```

### 6. Push the pending changes to the remote repository
```bash
git push origin main
```
```
To <remote-url>
   0c3d001..18760c4  main -> main
```

### 7. Observe the changes reflected on the remote
```bash
git log --oneline --all
```
```
18760c4 Git-T03-HOL_002: Add InventoryService skeleton
0c3d001 Initial commit
```

The remote history now matches local history — the branch was cleaned up and all
pending commits were pushed successfully.

## Key Git Commands Reference

| Command | Purpose |
|---|---|
| `git status` | Check working tree cleanliness / pending changes |
| `git branch -a` | List all local and remote-tracking branches |
| `git pull origin <branch>` | Fetch + merge latest remote changes into current branch |
| `git merge <branch> -m "<msg>"` | Merge another branch into the current one |
| `git push origin <branch>` | Push local commits to the remote repository |
| `git log --oneline --all --graph` | Visualize commit history across all branches |
