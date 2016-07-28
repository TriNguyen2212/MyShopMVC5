﻿using MyClassShop.Common;
using MyClassShop.Data.Infrastructure;
using MyClassShop.Data.Repositories;
using MyClassShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassShop.Service
{
    public interface IProductService
    {
        Product Add(Product Product);

        void Update(Product Product);

        Product Delete(int id);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAll(string keyword);

        Product GetById(int id);

        void Save();
    }

    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private ITagRepository _tagRepository;
        private IProductTagRepository _productTagRepository;
        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository,IProductTagRepository productTagRepository,ITagRepository tagRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
            this._productTagRepository = productTagRepository;
            this._tagRepository = tagRepository;
        }

        public Product Add(Product Product)
        {
            var product = _productRepository.Add(Product);
            _unitOfWork.Commit();
            if (!string.IsNullOrEmpty(Product.Tags))
            {
                string[] tags = Product.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tag);
                    }

                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = Product.ID;
                    productTag.TagID = tagId;
                    _productTagRepository.Add(productTag);
                }
            }
            return product;
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _productRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            else
                return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Product Product)
        {
            _productRepository.Update(Product);
            _productTagRepository.DeleteMulti(x => x.ProductID == Product.ID);
            if (!string.IsNullOrEmpty(Product.Tags))
            {
                string[] tags = Product.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tag);
                    }
                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = Product.ID;
                    productTag.TagID = tagId;
                    _productTagRepository.Add(productTag);
                }

            }
        }
    }
}
