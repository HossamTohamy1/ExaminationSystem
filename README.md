# 📝 Online Examination System

> A system for running exams online: instructors create quizzes, students take them, and results are calculated automatically.

---

## 🧐 What is this, in plain words?

Paper exams take time to print, hand out, and correct by hand — and grading 200 papers is exhausting.

This project is the **back-end (the "brain")** of an online exam platform:

- 📚 **Courses** — each instructor has courses, and students enroll in them.
- ❓ **Questions** — the instructor writes questions with multiple choices.
- 🧪 **Quizzes** — questions are grouped into a quiz for a course.
- ✍️ **Taking the exam** — students answer online.
- ✅ **Automatic results** — the system marks the answers and shows each student's score instantly.

## 👥 Who uses it?

| Who | What they can do |
|---|---|
| **Instructor** | Create courses, questions and quizzes; see students' results |
| **Student** | Join courses, take quizzes, see their scores |
| **Admin** | Manage users, instructors and courses |

## 🔄 How it works (the simple story)

```
Instructor creates a course ➜ Writes questions ➜ Builds a quiz
        ➜ Students take the quiz ➜ System grades it automatically ➜ Results are shown
```

---

## 🛠️ For developers

**Tech stack:** ASP.NET Core Web API (.NET 9) · ASP.NET Core Identity · Entity Framework Core + SQL Server · Repository pattern · AutoMapper · DTOs · Swagger

**Main entities:** `Course`, `Instructor`, `Student`, `Question`, `Choices`, `Quizzes`, `QuizQuestions`, `StudentExam`, `StudentAnswer`, `Result`

**Run locally**

1. Install the [.NET 9 SDK](https://dotnet.microsoft.com/download) and SQL Server.
2. Set your connection string in `Quizzes_System/appsettings.json`.
3. Run:
   ```bash
   cd Quizzes_System
   dotnet ef database update
   dotnet run
   ```
4. Open `/swagger` to try the API.

---

## 🇪🇬 بالعربي

نظام امتحانات أونلاين: المدرّس بيعمل كورسات ويكتب أسئلة اختيار من متعدد ويجمّعها في امتحان، والطالب بيحل الامتحان أونلاين، والنظام بيصحّح لوحده ويطلّع الدرجة على طول، من غير ورق ولا تصحيح يدوي.
