using AutoMapper;
using BaristaShop.Cargo.DtoLayer.Dtos.CargoCompanyDto;
using BaristaShop.Cargo.DtoLayer.Dtos.CargoCostumerDto;
using BaristaShop.Cargo.DtoLayer.Dtos.ShippingBillDto;
using BaristaShop.Cargo.DtoLayer.Dtos.ShippingDetailDto;
using BaristaShop.Cargo.DtoLayer.Dtos.ShippingOperationDto;
using BaristaShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaShop.Cargo.BusinessLayer.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<CargoCompany, CreateCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, UpdateCargoCompanyDto>().ReverseMap();

            CreateMap<CargoCustomer, CreateCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer,  UpdateCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, GetByIdCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, ResultCargoCustomerDto>().ReverseMap();

            CreateMap<ShipmentDetail, CreateShipmentDetailDto>().ReverseMap();
            CreateMap<ShipmentDetail, UpdateShipmentDetailDto>().ReverseMap();
            CreateMap<ShipmentDetail, GetByIdShipmentDetailDto>().ReverseMap();
            CreateMap<ShipmentDetail, ResultShipmentDetailDto>().ReverseMap();

            CreateMap<ShipmentOperation, CreateShipmentOperationDto>().ReverseMap();
            CreateMap<ShipmentOperation, UpdateShipmentOperationDto>().ReverseMap();
            CreateMap<ShipmentOperation, GetByIdShipmentOperationDto>().ReverseMap();
            CreateMap<ShipmentOperation, ResultShipmentOperationDto>().ReverseMap();

            CreateMap<ShippingBill, CreateShippingBillDto>().ReverseMap();
            CreateMap<ShippingBill, UpdateShippingBillDto>().ReverseMap();
            CreateMap<ShippingBill, GetByIdShippingBillDto>().ReverseMap();
            CreateMap<ShippingBill, ResultShippingBillDto>().ReverseMap();
        }
    }
}
