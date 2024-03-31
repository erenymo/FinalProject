using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation;

public static class ValidationTool
{
    public static void Validate(IValidator validator, object entity)
    {
        // buradaki context, ilgili bir thread'ı anlatır
        var context = new ValidationContext<object>(entity); // Product türü için Doğrulama Context'i oluştur.
        var result = validator.Validate(context);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }
    }
}