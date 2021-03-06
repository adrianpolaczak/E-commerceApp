using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EcommerceApp.Application.Interfaces;
using EcommerceApp.Application.ViewModels.EmployeePanel;
using EcommerceApp.Application.ViewModels.Home;
using EcommerceApp.Application.ViewModels.Product;
using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IImageConverterService _imageConverterService;
        private readonly IPaginatorService<ProductForListVM> _paginatorService;

        public ProductService(
            IMapper mapper,
            IProductRepository repository,
            IImageConverterService imageConverterService,
            IPaginatorService<ProductForListVM> paginatorService)
        {
            _mapper = mapper;
            _productRepository = repository;
            _imageConverterService = imageConverterService;
            _paginatorService = paginatorService;
        }

        public async Task AddProductAsync(ProductVM productVM)
        {
            var product = _mapper.Map<Product>(productVM);
            product.Image = await _imageConverterService.GetByteArrayFromFormFileAsync(productVM.FormFileImage);
            await _productRepository.AddProductAsync(product);
        }

        public async Task<ProductVM> GetProductAsync(int id)
        {
            var product = await _productRepository.GetProducts()
                .Include(c => c.Category)
            .FirstOrDefaultAsync(x => x.Id == id);
            var productVM = _mapper.Map<ProductVM>(product);
            productVM.ImageToDisplay = _imageConverterService.GetImageStringFromByteArray(product.Image);
            return productVM;
        }

        public async Task<ProductDetailsForUserVM> GetProductDetailsForUserAsync(int id)
        {
            var product = await _productRepository.GetProductAsync(id);
            var productVM = _mapper.Map<ProductDetailsForUserVM>(product);
            productVM.ImageToDisplay = _imageConverterService.GetImageStringFromByteArray(product.Image);
            return productVM;
        }

        public async Task<ProductListVM> GetPaginatedProductsAsync(int pageSize, int pageNumber)
        {
            var products = _productRepository.GetProducts().ProjectTo<ProductForListVM>(_mapper.ConfigurationProvider);
            var paginatedVM = await _paginatorService.CreateAsync(products, pageNumber, pageSize);
            return _mapper.Map<ProductListVM>(paginatedVM);
        }

        public async Task<HomeVM> GetRandomProductsWithImageAsync(int number)
        {
            var random = new Random();
            var products = _productRepository.GetProducts();
            products = products.OrderBy(x => x.Id);
            var count = await products.CountAsync();
            if (count > number)
            {
                var randomNumber = random.Next(count - number + 1);
                products = products.Skip(randomNumber);
            }
            products = products.Take(number);
            var productDetailsForHomeVMs = await products.ProjectTo<ProductDetailsForHomeVM>(_mapper.ConfigurationProvider).ToListAsync();
            for (int i = 0; i < productDetailsForHomeVMs.Count; i++)
            {
                productDetailsForHomeVMs[i].ImageToDisplay = _imageConverterService.GetImageStringFromByteArray(productDetailsForHomeVMs[i].Image);
            }
            return new HomeVM
            {
                Products = productDetailsForHomeVMs
            };
        }

        public async Task<ListProductDetailsForUserVM> GetProductsByCategoryIdAsync(int id)
        {
            var products = await _productRepository.GetProducts().Where(x => x.Category.Id == id).ToListAsync();
            var productVMs = _mapper.Map<List<ProductDetailsForUserVM>>(products);
            for (int i = 0; i < productVMs.Count; i++)
            {
                productVMs[i].ImageToDisplay = _imageConverterService.GetImageStringFromByteArray(products[i].Image);
            }
            return new ListProductDetailsForUserVM
            {
                Products = productVMs
            };
        }

        public async Task UpdateProductAsync(ProductVM productVM)
        {
            var product = _mapper.Map<Product>(productVM);
            product.Image = await _imageConverterService.GetByteArrayFromFormFileAsync(productVM.FormFileImage);
            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }
    }
}
