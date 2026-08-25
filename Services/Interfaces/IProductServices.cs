using ProductCatalog.API.Entities.Products;


namespace ProductCatalog.API.Services.Interfaces
{
    public interface IProductServices
    {

        Product Create(Product product);//criar
        Product FindById(long id);//buscar um produto específico pelo seu ID.
        List<Product> FindAll();//buscar todos os produtos cadastrados.
        List<Book> FindAllBooks();//apenas book
        List<Game> FindAllGames();//apenas jogos
        Product? Update (Product product);//atualizar
        Book? UpdateBook(Book book);//atualizar books
        Game? UpdateGame (Game game);//atualizar games
        bool Delete(long id);//deletar
    }
}
/*
 
Método	Poderia ser void?	Por que geralmente retorna algo?
Create	Sim	Para devolver o objeto criado com o ID gerado
Delete	Sim (normalmente é)	Só precisa confirmar que removeu
Update	Sim	Mas geralmente retorna o objeto atualizado
FindById	Não faria sentido	Precisa retornar o produto encontrado

No CRUD real, o padrão mais comum é:

Create → retorna o objeto criado
Read → retorna dados
Update → retorna o objeto atualizado
Delete → retorna nada (void) ou apenas sucesso/falha.
 
 */