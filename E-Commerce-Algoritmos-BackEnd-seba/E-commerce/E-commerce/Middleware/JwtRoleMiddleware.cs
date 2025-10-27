using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class JwtRoleMiddleware
{
    private readonly RequestDelegate _next;

    public JwtRoleMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (string.IsNullOrEmpty(token))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Token no proporcionado");
            return;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes("p9X$7v@Lk#3rT!zQw8mN^2sYbG0eHjUd");

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = "EcommerceApp",
                ValidAudience = "EcommerceApp",
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var role = jwtToken.Claims.First(x => x.Type == ClaimTypes.Role).Value;

            if (context.Request.Path.StartsWithSegments("/admin") && role != "Administrador")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Acceso denegado: no sos administrador");
                return;
            }

            await _next(context);
        }
        catch
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Token inválido");
        }
    }
}
