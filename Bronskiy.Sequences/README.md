## About

This library provides a generator, that generates lazily evaluated sequences from functions. This library targets **.NET 8 and higher**.

## Key Features

- Generate values with or without passing an index to the factory function.
- Generate values for a specified count, starting index, or `Range`.

## How to Use

```csharp
using System;
using System.Collections.Generic;
using Bronskiy.Sequences;

IEnumerable<int> squares = Sequence<int>.Generate(
    count: 5,
    func: index => index * index);

foreach (int square in squares)
{
    Console.WriteLine(square);
}
```

Generation without an index:

```csharp
IEnumerable<Guid> ids = Sequence<Guid>.Generate(
    count: 3,
    func: Guid.NewGuid);
```

Generation with a specified index:

```csharp
IEnumerable<int> values = Sequence<int>.Generate(
    start: 10,
    count: 3,
    func: index => index);
```

Generation with a Range:

```csharp
IEnumerable<int> values = Sequence<int>.Generate(
    range: new Range(2, 5),
    func: index => index);
```

## Main Types

The main type is:

- **`Sequence<T>`** — provides methods for generating sequences of `T`.

## Feedback & Contributing

You can report a bug or contribute at [the GitHub repository](https://github.com/bronsk1y/Bronskiy.Sequences).
