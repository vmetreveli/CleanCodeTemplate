namespace  {{cookiecutter.Namespace}}.{{cookiecutter.ProjectName}}.Application.Exceptions;

public sealed record ValidationError(string PropertyName, string ErrorMessage);