import {Resolver, Query, Ctx} from 'type-graphql';
import { Product } from '../../entities/product';
import { ApiContext } from '../graphqlTypes/context';

@Resolver()
export class BusinessRegistrationReolver{
  @Query(() => [Product])
  async Hello(@Ctx() context: ApiContext)
  {
    return context.dataSources.productAPI.getProducts();
  }
}