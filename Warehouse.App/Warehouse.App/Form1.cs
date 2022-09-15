using Warehouse.Repository.Interfaces;
using Warehouse.Entity;

namespace Warehouse.App;

public partial class Form1 : Form
{
    private readonly IAccountRepository _accountRepository;
    private readonly IProductRepository _productRepository;

    public Form1(IAccountRepository accountRepository,
                 IProductRepository productRepository)
    {
        InitializeComponent();

        _accountRepository = accountRepository;
        _productRepository = productRepository;
    }

    protected async override void OnLoad(EventArgs e)
    {
        dataGridView1.DataSource = await _accountRepository.GetAllAsync();
    }
}
