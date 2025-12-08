# UnsafeAccessorSamples

This project demonstrates how to use the `UnsafeAccessor` attribute in C# to access private members. This is a new feature introduced in .NET 8 that allows developers to access private constructors, methods, properties, and fields in a high-performance manner.

## 📋 Table of Contents

- [Introduction](#introduction)
- [Sample List](#sample-list)
- [System Requirements](#system-requirements)
- [How to Run](#how-to-run)
- [Performance Comparison](#performance-comparison)
- [Version Differences](#version-differences)
- [Important Notes](#important-notes)
- [References](#references)
- [License](#license)

## 🚀 Introduction

`UnsafeAccessor` is a new feature introduced in .NET 8 that provides a high-performance and type-safe way to access private members, offering better performance compared to Reflection. This feature is primarily used for testing, framework development, or scenarios that require access to internal implementations.

## 📚 Sample List

### Sample001 - Private Instance Member Access
**Target Framework**: .NET 10  
**Features**: Demonstrates how to access private constructors, methods, and fields
- ✅ Private constructor access
- ✅ Private method invocation
- ✅ Private field reading and modification

### Sample002 - Private Property Access
**Target Framework**: .NET 10  
**Features**: Demonstrates how to access getters and setters of private properties
- ✅ Private property reading (`get_PropertyName`)
- ✅ Private property writing (`set_PropertyName`)

### Sample003 - Static Member Access
**Target Framework**: .NET 10  
**Features**: Demonstrates how to access private static members of classes
- ✅ Private static field access
- ✅ Private static method invocation

### Sample004 - Generic Class Limitations (.NET 8)
**Target Framework**: .NET 8  
**Features**: Shows the limitations of generic UnsafeAccessor in .NET 8
- ✅ Generic class constructor access (success)
- ❌ Generic class method access (fails, throws `MissingMethodException`)

### Sample005 - Generic Support (.NET 9+)
**Target Framework**: .NET 10  
**Features**: Shows generic UnsafeAccessor support starting from .NET 9
- ✅ Full generic class support
- ✅ Generic method access

### Sample006 - Nested Class Access (.NET 10)
**Target Framework**: .NET 10  
**Features**: Access private nested classes using `UnsafeAccessorType` attribute
- ✅ Private nested class access
- ✅ Nested class method invocation

### Sample007 - External Class Static Methods
**Target Framework**: .NET 10  
**Features**: Access static methods of external classes (e.g., System.Math)
- ✅ System.Math.Sqrt method access
- ✅ System.Math.Pow method access

### BenchmarkTest - Performance Testing
**Target Framework**: .NET 10  
**Features**: Use BenchmarkDotNet to compare performance of different access methods
- 🏆 Direct access
- 🥈 UnsafeAccessor
- 🥉 Reflection

## ⚙️ System Requirements

- **.NET 8 ~ .NET 10 or higher**
- **Visual Studio 2026** (latest version recommended)
- **BenchmarkDotNet** (required for performance testing)

## 🔧 How to Run

1. **Clone the project**
2. **Run specific samples**
3. **Run performance tests**

## 📊 Performance Comparison

Based on BenchmarkDotNet test results (tested on Intel Core i7-1265U):

| Access Method | Average Time | Memory Allocation | Relative Performance |
|---------------|-------------|-------------------|---------------------|
| Direct Access | 0.0008 ns | 0 B | 🏆 Fastest |
| UnsafeAccessor | 0.0019 ns | 0 B | 🥈 Extremely Fast |
| Reflection | 18.5785 ns | 48 B | 🥉 Slower |

**Conclusion**: UnsafeAccessor performance is almost identical to direct access, about 9000 times faster than reflection!

## 📋 Version Differences

### .NET 8
- ✅ Basic UnsafeAccessor support
- ❌ Generic class method access limitations

### .NET 9
- ✅ Full generic UnsafeAccessor support
- ✅ Improved type inference

### .NET 10
- ✅ UnsafeAccessorType attribute
- ✅ Nested class access support
- ✅ Improved diagnostic messages

## ⚠️ Important Notes

1. **Security Considerations**: UnsafeAccessor bypasses encapsulation and should be used with caution
2. **Maintainability**: Excessive use may make code difficult to maintain
3. **Version Compatibility**: Private members may change in version updates
4. **Use Cases**: Primarily suitable for testing, framework development, and performance-critical scenarios

## 📝 Usage Examples

### Basic Syntax

```csharp
// Example of using UnsafeAccessor to access private member
var instance = new TargetClass();
var accessor = instance.UnsafeAccessor();

accessor.Invoke("PrivateMethodName", param1, param2);
var fieldValue = accessor.Field<int>("<FieldName>k__BackingField");
accessor.FieldSet("<FieldName>k__BackingField", newValue);
```

### Advanced Scenario - Generic Usage

```csharp
// Example of using UnsafeAccessor with generics (requires .NET 9 or higher)
var list = new List<int> { 1, 2, 3 };
var accessor = list.UnsafeAccessor();

// Access private field "_items" of the list
var itemsField = accessor.Field<int[]>("_items");

// Modify the private field
itemsField[0] = 42;
```

## 🔗 References

- [Microsoft Official Documentation - UnsafeAccessor](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.unsafeaccessorattribute)
- [.NET 9 Breaking Changes - UnsafeAccessor](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/9.0/unsafeaccessor-generics)
- [BenchmarkDotNet Official Website](https://benchmarkdotnet.org/)

## 📄 License

This project is licensed under the [MIT License](LICENSE.txt).

## 🤝 Contributing

Issues and Pull Requests are welcome to improve this project!

---

**Note**: This sample is for learning and reference purposes only. When using UnsafeAccessor in production projects, please carefully evaluate its necessity and risks.