// See https://aka.ms/new-console-template for more information
using Basic.Console.Application.Samples.SpecialCharacter;

Console.WriteLine("Hello, World!");

//var result = SpecialCharacter.ValidateInputData("()");

// Console.WriteLine("String Valid Result :==>>" + result);

string text = "()";
Console.WriteLine("Original string: " + text);
Console.WriteLine("Verify the said string contains valid parentheses: " + SpecialCharacter.IsValidStringWithReplaceFunction(text));
text = "<>()[]{}";
Console.WriteLine("Original string: " + text);
Console.WriteLine("Verify the said string contains valid parentheses: " + SpecialCharacter.IsValidStringWithReplaceFunction(text));
text = "(<>]";
Console.WriteLine("Original string: " + text);
Console.WriteLine("Verify the said string contains valid parentheses: " + SpecialCharacter.IsValidStringWithReplaceFunction(text));
text = "[<>()[]{}]";
Console.WriteLine("Original string: " + text);
Console.WriteLine("Verify the said string contains valid parentheses: " + SpecialCharacter.IsValidStringWithReplaceFunction(text));

text = "]>)[<(";
Console.WriteLine("Original string: " + text);
Console.WriteLine("Verify the said string contains valid parentheses: " + SpecialCharacter.IsValidString(text));

Console.ReadLine();