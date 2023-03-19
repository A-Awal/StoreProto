import {
  BaseEntity,
  ManyToOne,
  JoinColumn,
  Column,
  Entity,
  PrimaryGeneratedColumn,
  ManyToMany,
} from "typeorm";
import { Store } from "./business";
import { Order } from "./order";
import {ObjectType, Field} from 'type-graphql';

enum Category {
  Blog = "Blog",
  Finance = "Finance",
  Ecommerce = "e-Commerce",
}

@ObjectType()
@Entity("product")
export class Product extends BaseEntity {
  @Field()
  @PrimaryGeneratedColumn()
  id: number;

  @Field()
  @Column()
  ProductName: string;

  @Field()
  @Column()
  ProductCategory: Category;

  @Field()
  @Column()
  ProductDescription: string;

  @Field()
  @Column()
  UnitOfMeasurement: string;

  @Field()
  @Column()
  Quantity: string;

  @Field( () => [Order])
  @ManyToMany(() => Order, (Order) => Order.products)
  Orders: Order[];

  @Field(() => Store)
  @ManyToOne(() => Store, (store) => store.Inventory, { nullable: true, onDelete: "CASCADE" })
  @JoinColumn({
    name: "business_id",
  })
  Store: Store;
}
