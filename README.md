## About

This library provides a generator, that generates lazily evaluated sequences from functions. This library targets **.NET 8 and higher**.

## Key Features

- Generate values with or without passing an index to the factory function.
- Generate values for a specified count, starting index, or `Range`.

## How to Use

Generate values from their zero-based index:

```csharp
IEnumerable<int> squares = Sequence<int>.Generate(5, index => index * index);
```

Generate values without an index:

```csharp
IEnumerable<Guid> ids = Sequence<Guid>.Generate(3, Guid.NewGuid);
```

Generate values from a starting index with a step:

```csharp
IEnumerable<int> oddNumbers = Sequence<int>.Generate(1, 5, 2, index => index);
```

Generate values over a range with a negative step:

```csharp
IEnumerable<int> descending = Sequence<int>.Generate(new Range(5, 0), -1, index => index);
```

## Main Types

The main type is:

- **`Sequence<T>`**

## Feedback & Contributing

You can report a bug or contribute at [the GitHub repository](https://github.com/bronsk1y/Bronskiy.Sequences).
