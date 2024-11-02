namespace CalendarWebApi.Controllers.Validators
{
   public class ValidatorFactory
    {
        public IValidator GetValidator(string platform)
        {
            return platform switch
            {
                "LaNacion" => new LaNacionValidator(),
                _ => throw new ArgumentException("Plataforma no válida", nameof(platform)),
            };
        }
    }
}