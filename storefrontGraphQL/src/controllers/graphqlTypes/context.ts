const ProductAPI = require('./DataSources/dataSources');

export interface HttpContext
{
    req: Request;
    res: Response;  
}

export interface ApiContext
{
    dataSources: {
        productAPI: typeof ProductAPI;
      };  
}