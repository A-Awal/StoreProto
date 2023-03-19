
import { DataSourceOptions } from "typeorm";
import { User } from "./entities/user";
import { Store } from "./entities/business";
import { Product } from "./entities/product";
import { Order } from "./entities/order";
import { Token } from "./entities/token";
"Server=ep-mute-pine-009922.us-west-2.aws.neon.tech; Port=5432; User Id=A-Awal; Password=G3LrmV0yWMio; Database=neondb"
const config: DataSourceOptions = {
  type: "postgres",
  host: "ep-mute-pine-009922.us-west-2.aws.neon.tech",
  port: 5432,
  username: 'A-Awal',
  password: "G3LrmV0yWMio",
  database: 'neondb',
  entities: [],
  migrations: [__dirname + "/migrations/*{.ts,.js}"],
  synchronize: false,
  ssl: true,
  migrationsRun: false,
  logging: true,
  // dropSchema: true
};

export default config;