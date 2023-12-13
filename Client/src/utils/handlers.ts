export const jsonToQueryString = (o: any): string => {

  let listQuery: string = ""
  Object.keys(o).forEach(k => {
    if(o[k] != null && o[k] !== undefined) {
      if(o[k].constructor.toString().indexOf("Array") > -1) {
        for (let index = 0; index < o[k].length; index++) {
          listQuery = listQuery !== "" ? listQuery + "&" + k + "=" + o[k][index] : k + "=" + o[k];
        }
      }
      else {
        listQuery = listQuery !== "" ? listQuery + "&" + k + "=" + o[k] : k + "=" + o[k];
      }
    }
  })

  return listQuery;
};


export const noteTruncate = (str: string, n: number): string => {
    return (str.length > n) ? str.slice(0, n - 1) + " ..." : str;
}
