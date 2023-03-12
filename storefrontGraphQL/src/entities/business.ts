import {
  BaseEntity,
  Column,
  Entity,
  JoinColumn,
  ManyToOne,
  OneToMany,
  PrimaryGeneratedColumn,
} from "typeorm";
import { User } from "./user";
import { Product } from "./product";
import {ObjectType, Field} from 'type-graphql';

enum BusinessType {
  Blog = "Blog",
  eCommerce = "E-commerce",
  Finance = "Financial Services",
}
@ObjectType()
@Entity("Store")
export class Store extends BaseEntity {
  @Field()
  @PrimaryGeneratedColumn('uuid')
  StoreId: string;

  @Field()
  @Column()
  StoreName: string;

  @Field()
  @Column()
  businesType: BusinessType;

  @ManyToOne(() => User, (user) => user.business,)
  @JoinColumn({name: "user_id"})
  user: User;

  @OneToMany(() => Product, (product) => product.Store, {
    nullable: true,
  })
  Inventory: Product[];
}
