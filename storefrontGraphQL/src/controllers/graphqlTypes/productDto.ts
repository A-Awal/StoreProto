import {ObjectType, Field} from 'type-graphql';

@ObjectType()
export class ProductDto
{
    @Field( () => String)
    id: string;

    @Field( () => String)
    productName: string;

    @Field( () => String)
    productDescription: string;

    @Field( () => String)
    productCategory: string;

    @Field( () => String)
    unit: string;

    @Field( () => Number)
    quantity: number;
  }