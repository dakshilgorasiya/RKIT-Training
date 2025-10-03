# Design Choices: Abstract vs. Sealed Classes

In this project, the `abstract` and `sealed` keywords are used deliberately to create a robust, predictable, and maintainable architecture. This document explains the reasoning behind these choices.

-----

## 🏛️ The Role of `abstract` Classes (The Blueprint)

An **`abstract`** class is intentionally incomplete. It acts as a common blueprint or contract that other classes must follow.

In my pipeline, `FileImporter<T>` is the perfect example:

```csharp
public abstract class FileImporter<T>
```

### **Reasoning**

1.  **Enforcing a Contract**: `FileImporter<T>` guarantees that any class inheriting from it *must* provide an implementation for the `Import` method. This ensures all importers conform to the pipeline's expectations. We can treat any importer object polymorphically, knowing the `Import` method will always exist.

2.  **Preventing Instantiation**: You cannot create an instance of a generic "FileImporter" (`new FileImporter<Book>()` is invalid). This is logical because the base class itself doesn't know *how* to parse a file; it only defines the *concept* of an importer.


-----

## 🧱 The Role of `sealed` Classes (The Finished Product)

A **`sealed`** class is intentionally complete and final. It explicitly forbids other classes from inheriting from it.

Classes like `CsvBookImporter` and `XmlReportWriter` are marked as `sealed`:

```csharp
public sealed class JsonReportWriter : IReportWriter<Report>
```

### **Reasoning**

1.  **Communicating Design Intent**: The primary reason is clarity. `sealed` tells other developers, "This class does one specific thing perfectly. It is a finished component, not a base for something else." There is no logical reason to create a `SlightlyModifiedCsvBookImporter` that inherits from `CsvBookImporter`. 
2.  **Ensuring Stability & Predictability**:  If a class is not designed to be a base class, allowing inheritance can lead to unexpected behavior when subclasses are used. Sealing the class prevents this misuse and makes its behavior entirely predictable.

3.  **Performance Optimizations**: When the JIT (Just-In-Time) compiler encounters a method call on a `sealed` class instance, it knows that the method cannot be overridden. This allows it to perform optimizations.


-----

## Summary

| Keyword        | `abstract class FileImporter<T>`                               | `sealed class CsvBookImporter`                                  |
| -------------- | -------------------------------------------------------------- | --------------------------------------------------------------- |
| **Purpose** | Defines a common template/contract                             | Provides a specific, complete implementation                  |
| **Inheritance**| **Designed to be** a parent (must be inherited from)           | **Designed to be** final (cannot be inherited from)             |
| **Usage** | Use when you want to enforce a common structure for subclasses. | Use when a class is a complete implementation and not a blueprint. |
| **Analogy** | Blueprint 📝                                                   | Finished Component 🧱                                            |