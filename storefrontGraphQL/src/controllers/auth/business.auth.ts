import {Resolver, Query, Ctx} from 'type-graphql';
import { Product } from '../../entities/product';
import { ApiContext } from '../graphqlTypes/context';
import { ProductDto } from '../graphqlTypes/productDto';

@Resolver()
export class BusinessRegistrationReolver{
  @Query(() => [ProductDto])
  async Hello(@Ctx() context: ApiContext)
  {
    return context.dataSources.productAPI.getProducts();
  }
}