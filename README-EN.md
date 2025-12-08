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