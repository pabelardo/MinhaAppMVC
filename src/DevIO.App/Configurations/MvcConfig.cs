using Microsoft.AspNetCore.Mvc;

namespace DevIO.App.Configurations
{
    public static class MvcConfig
    {
        public static void AddMvcConfiguration(this IServiceCollection services)
        {
            const string invalidValueMsg = "O valor preenchido é inválido para este campo.";
            const string beNumericMsg = "O campo deve ser numérico.";
            const string requiredValueMsg = "Este campo precisa ser preenchido.";
            const string bodyRequiredMsg = "É necessário que o body na requisição não esteja vazio.";

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllersWithViews(o =>
            {
                o.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => invalidValueMsg);
                o.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(x => requiredValueMsg);
                o.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => requiredValueMsg);
                o.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(() => bodyRequiredMsg);
                o.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor(x => invalidValueMsg);
                o.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() => invalidValueMsg);
                o.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() => beNumericMsg);
                o.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor((x) => invalidValueMsg);
                o.ModelBindingMessageProvider.SetValueIsInvalidAccessor(x => invalidValueMsg);
                o.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(x => beNumericMsg);
                o.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => requiredValueMsg);

                o.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()); //Valida token em todos os requests
            }).AddRazorRuntimeCompilation();

            services.AddRazorPages();
        }
    }
}