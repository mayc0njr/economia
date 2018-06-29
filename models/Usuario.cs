namespace economia
{
    public class Usuario
    {
        public string Nome { get; }
        public string Email { get; }

        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
