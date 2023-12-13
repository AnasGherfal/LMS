export interface StatusLookup {
  text: string;
  value: any;
}

export const status = {
  all: null,
  active: 1,
  locked: 2,
};

export const userStatus = {
  all: -1,
  active: 1,
  locked: 2,
};

export const statusLookup: StatusLookup[] = [
    { text: "كل الحالات", value: status.all },
    { text: "مفعل", value: status.active },
    { text: "موقوف", value: status.locked },
];
