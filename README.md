# UnsafeAccessorSamples

這個專案演示了如何在 C# 中使用 `UnsafeAccessor` 特性來存取私有成員，這是 .NET 8 引入的一項新功能，讓開發者能夠以高效能的方式存取類別的私有建構函式、方法、屬性和欄位。

## 📋 目錄

- [簡介](#簡介)
- [範例清單](#範例清單)
- [系統需求](#系統需求)
- [如何執行](#如何執行)
- [效能比較](#效能比較)
- [版本差異](#版本差異)
- [重要注意事項](#重要注意事項)
- [參考資源](#參考資源)
- [授權條款](#授權條款)

## 🚀 簡介

`UnsafeAccessor` 是 .NET 8 引入的新特性，提供了一種高效能且類型安全的方式來存取私有成員，相比於反射 (Reflection) 具有更好的效能表現。此特性主要用於測試、框架開發或需要存取內部實作的場景。

## 📚 範例清單

### Sample001 - 私有實例成員存取
**目標框架**: .NET 10  
**功能**: 演示如何存取私有建構函式、方法和欄位
- ✅ 私有建構函式存取
- ✅ 私有方法調用
- ✅ 私有欄位讀取和修改

### Sample002 - 私有屬性存取
**目標框架**: .NET 10  
**功能**: 演示如何存取私有屬性的 getter 和 setter
- ✅ 私有屬性讀取 (`get_PropertyName`)
- ✅ 私有屬性寫入 (`set_PropertyName`)

### Sample003 - 靜態成員存取
**目標框架**: .NET 10  
**功能**: 演示如何存取類別的私有靜態成員
- ✅ 私有靜態欄位存取
- ✅ 私有靜態方法調用

### Sample004 - 泛型類別限制 (.NET 8)
**目標框架**: .NET 8  
**功能**: 展示 .NET 8 中泛型 UnsafeAccessor 的限制
- ✅ 泛型類別建構函式存取 (成功)
- ❌ 泛型類別方法存取 (失敗，拋出 `MissingMethodException`)

### Sample005 - 泛型支援 (.NET 9+)
**目標框架**: .NET 10  
**功能**: 展示 .NET 9 開始支援的泛型 UnsafeAccessor
- ✅ 完整的泛型類別支援
- ✅ 泛型方法存取

### Sample006 - 巢狀類別存取 (.NET 10+)
**目標框架**: .NET 10  
**功能**: 使用 `UnsafeAccessorType` 特性存取私有巢狀類別
- ✅ 私有巢狀類別存取
- ✅ 巢狀類別方法調用

### Sample007 - 外部類別靜態方法
**目標框架**: .NET 10  
**功能**: 存取外部類別（如 System.Math）的靜態方法
- ✅ System.Math.Sqrt 方法存取
- ✅ System.Math.Pow 方法存取

### BenchmarkTest - 效能測試
**目標框架**: .NET 10  
**功能**: 使用 BenchmarkDotNet 比較不同存取方式的效能
- 🏆 直接存取
- 🥈 UnsafeAccessor
- 🥉 反射 (Reflection)

## ⚙️ 系統需求

- **.NET 8 ~ .NET 10或更高版本**
- **Visual Studio 2026** (建議使用最新版本)
- **BenchmarkDotNet** (效能測試需要)

## 🔧 如何執行

1. **複製專案**
2. **開啟解決方案於 Visual Studio 中**
3. **執行效能測試**

## 📊 效能比較

根據 BenchmarkDotNet 測試結果 (在 Intel Core i7-1265U 上測試)：

| 存取方式 | 平均時間 | 記憶體分配 | 相對效能 |
|----------|----------|------------|----------|
| 直接存取 | 0.0008 ns | 0 B | 🏆 最快 |
| UnsafeAccessor | 0.0019 ns | 0 B | 🥈 極快 |
| 反射 | 18.5785 ns | 48 B | 🥉 較慢 |

**結論**: UnsafeAccessor 的效能幾乎與直接存取相同，比反射快約 9000 倍！

## 📋 版本差異

### .NET 8
- ✅ 基本 UnsafeAccessor 支援
- ❌ 泛型類別方法存取限制

### .NET 9
- ✅ 完整泛型 UnsafeAccessor 支援
- ✅ 改善的類型推斷

### .NET 10
- ✅ UnsafeAccessorType 特性
- ✅ 巢狀類別存取支援
- ✅ 改善的診斷訊息

## ⚠️ 重要注意事項

1. **安全性考量**: UnsafeAccessor 繞過了封裝性，應謹慎使用
2. **維護性**: 過度使用可能會讓程式碼難以維護
3. **版本相容性**: 私有成員可能在版本更新時變更
4. **使用場景**: 主要適用於測試、框架開發和效能關鍵場景

## 📝 使用範例

### 基本語法

```csharp
// UnsafeAccessorSamples/SomeClass.cs
using System;
using System.Runtime.CompilerServices;

public class SomeClass
{
    private int secretNumber = 42;
    private static string secretMessage = "Hello, UnsafeAccessor!";

    private void RevealSecret()
    {
        Console.WriteLine($"Secret Number: {secretNumber}, Message: {secretMessage}");
    }
}

// UnsafeAccessorSamples/Program.cs
using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {
        var someClassInstance = new SomeClass();
        
        // 存取私有欄位
        var secretNumber = (int)UnsafeAccessor.Access(someClassInstance, "secretNumber");
        Console.WriteLine($"Secret Number: {secretNumber}");
        
        // 存取私有静態欄位
        var secretMessage = (string)UnsafeAccessor.Access(typeof(SomeClass), "secretMessage", true);
        Console.WriteLine($"Secret Message: {secretMessage}");
        
        // 調用私有方法
        UnsafeAccessor.Invoke(someClassInstance, "RevealSecret");
    }
}
```

## 🔗 參考資源

- [Microsoft 官方文件 - UnsafeAccessor](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.unsafeaccessorattribute)
- [.NET 9 Breaking Changes - UnsafeAccessor](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/9.0/unsafeaccessor-generics)
- [BenchmarkDotNet 官網](https://benchmarkdotnet.org/)

## 📄 授權條款

本專案使用 [MIT 授權條款](LICENSE.txt)。

## 🤝 貢獻

歡迎提交 Issues 和 Pull Requests 來改善這個專案！

---

**注意**: 本範例僅供學習和參考用途，在正式專案中使用 UnsafeAccessor 時請謹慎評估其必要性和風險。