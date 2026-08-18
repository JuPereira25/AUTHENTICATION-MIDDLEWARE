public class TokenValidation
{
    public bool IsValid(string? token)
    {
        var AcessToken = "vYQIYxOpyfr";
        if(token == AcessToken)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}