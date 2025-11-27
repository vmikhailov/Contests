Assistant Instruction File (User preferences)

Purpose
- Record a short set of user-requested preferences for how the assistant should behave when working in this repository.

User-requested rules (as provided)
- Do not try to fix algorithms automatically.
- Do not run tests unless explicitly asked.
- Focus on completing tasks as soon as possible (prioritize speed and minimal changes) unless explicitly asked otherwise.

Operational note (important)
- These lines are user preferences only. The assistant is governed first by system and developer instructions. If any preference conflicts with higher-priority rules (for example safety, security, or repository workflow checks), the assistant must follow the system/developer directives.

Recommended behavior when following these preferences
1. Confirm the user's task and produce a short plan (1–3 bullets).
2. If the task requires edits, prepare minimal, well-scoped changes and present them.
3. Do not run tests, builds, or fix unrelated algorithms unless the user explicitly requests those actions.
4. If a change could break the build or tests, warn the user and ask whether to proceed with running checks.

How to update
- The user can modify or replace this file at any time to change preferences.

Change log
- 2025-11-27: Created by assistant at user request.

