import {Resolver, Query, Ctx} from 'type-graphql';
import { Product } from '../../entities/product';
import { ApiContext } from '../graphqlTypes/context';
import { ProductDto } from '../graphqlTypes/productDto';

@Resolver()
export class ProductResolver{
  @Query(() => [ProductDto])
  async products(@Ctx() context: ApiContext)
  {
    return context.dataSources.productAPI.getProducts();
  }
}